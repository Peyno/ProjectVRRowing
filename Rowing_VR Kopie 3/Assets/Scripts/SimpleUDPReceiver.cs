using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine.Events;

public class SimpleUDPReceiver : MonoBehaviour
{
    private const int ReceivePollingTime = 500000;

    public UnityEvent<String> OnReceivedJson = new UnityEvent<string>();

    private Socket socket;
    private EndPoint remoteEndPoint;
    bool isRunning = false;
    private byte[] receivedData;

    float timeSinceLastPoll = .0f;
    float pollTimer = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        receivedData = new byte[1024 * 1024];
        OpenSocket();
    }

    void OpenSocket(IPAddress listenAddress = null, ushort port = 8081)
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPAddress any = IPAddress.Any;
        socket.SendBufferSize = 1024 * 1024;
        socket.ReceiveBufferSize = 1024 * 1024;
        socket.Bind(new IPEndPoint(any, port));

        remoteEndPoint = new IPEndPoint(any, 0);
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastPoll += Time.deltaTime;

        if(timeSinceLastPoll > pollTimer)
        {
            timeSinceLastPoll = .0f;
            Receive();
        }
    }

    void Receive()
    {
        if (!isRunning)
            return;

        bool tryReceiveMore = true;
        while (tryReceiveMore)
        {
            int byteCount = 0;
            try
            {
                if (socket.Available > 0 && socket.Poll(ReceivePollingTime, SelectMode.SelectRead))
                    byteCount = socket.ReceiveFrom(receivedData, SocketFlags.None, ref remoteEndPoint);
                else
                    tryReceiveMore = false;
            }
            catch (SocketException ex)
            {
                tryReceiveMore = false;
                switch (ex.SocketErrorCode)
                {
                    case SocketError.Interrupted:
                    case SocketError.NotSocket:
                        isRunning = false;
                        break;
                    case SocketError.ConnectionReset:
                    case SocketError.MessageSize:
                    case SocketError.TimedOut:
                        break;
                    default:
                        break;
                }
            }
            catch (ObjectDisposedException)
            {
                tryReceiveMore = false;
                isRunning = false;
            }
            catch (NullReferenceException)
            {
                tryReceiveMore = false;
                isRunning = false;
            }

            if (byteCount > 0)
                OnDataReceived(receivedData, byteCount, (IPEndPoint)remoteEndPoint);
        }
    }

    protected void OnDataReceived(byte[] dataBuffer, int amount, IPEndPoint fromEndPoint)
    {
        //tring receivedString = BitConverter.ToString(dataBuffer);
        string receivedString = System.Text.Encoding.Default.GetString(dataBuffer);
        OnReceivedJson.Invoke(receivedString);
       // Debug.Log("data" + receivedString); 
    }
}
