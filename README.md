## Server.CS
### 지식공유자 : [Rookiss](https://www.inflearn.com/instructors/230375/courses)
## 교육 일기 
### 1020_멀티 쓰레드 개론, 쓰레드 생성, 컴파일러의 최적화
서버를 구축하기 위해 필요한 **멀티 쓰레드** 지식과 쓰레드를 코드상에서 어떻게 사용하는지 기본적인 방법에 대해 배웠고 컴파일러가 **Release**상태에서 코드를 실행할 때 어떤 최적화가 일어나는지 그리고 그 최적화 구간에 쓰레드의 변화에 대해 배웠습니다. 또 **Volatile** 문법에 대해서도 간략하게나마 배웠습니다. 멀티 쓰레드는 **Heap 영역을 공유하며 각자 쓰레드마다 Stack 영역**을 보유하고 있습니다.
### 1021_캐시 이론, 메모리 배리어, InterLocked, Lock 기초, DeadLock, Lock 구현 이론
코어에 내장되어있는 캐시에 대해 알아봤으며 캐시가 어떻게 작동하는지 또 어떤 특성이 있는지 배웠습니다. **메모리 배리어**는 **코드 재배치를 억제**하고 *(컴파일러 최적화시 코드의 순서가 뒤바뀔 가능성이 있음)* *가시성*을 보장한다는것을 배웠습니다. **Interlocked** 클래스를 이용해 값을 증가시키거나 감소시킬 때 생기는 세 단계를 단일 작업으로 처리시켜줍니다. **Atomic(원자성)** 이라고도 합니다. 또 Lock 키워드에 대해 배웠습니다. **Monitor.Enter, Exit**와 비슷한 기능을 하되 좀 더 간략하게 변화된 형태입니다. 매개변수로는 object를 받으며 문자 그대로 자물쇠의 역할을 합니다. 어떤 경우에는 **DeadLock** 현상을 일으키며 DeadLock은 **상호 배제(Mutual Exclusion)** 가 일어날 경우에 나타나는것이 일반적입니다. Lock 구현 이론에서는 Lock을 어떤식으로 배치하는지에 대해 간략하게 배웠습니다. 
### 1129_SpinLock
*CAS(Compare-And-Swap)* 를 이용하는 Lock 구현 방식이며 *Interlocked.CompareExchange(ref original, desired, expected)* 함수를 이용해서 구현합니다.  
### 0117_SpinLock 복습, Context Switching, AutoResetEvent, ManualResetEvent, Mutex, ReaderWriteLock
오랜만에 다시 강의를 듣게 되서 전에 들었던 강의인 SpinLock 강의를 들으면서 마음을 다잡았고 Context Switching이 어떤 것인지 또 어떤 종류로 나뉘어서 활용하게 되는지 배웠습니다. AutoResetEvent와 ManualResetEvent, Mutex, ReaderWriteLock 등 바로 설명하기 어려운 부분은 따로 정보를 더 찾아봐야 할 것같습니다.	
### 0117_ReaderWriteLock 연습, TLS(Thread Local Storage), Parallel 라이브러리
*ReaderWriteLock* 클래스가 어떤식으로 작동하는지 내부 함수를 구현하는 연습을 했습니다. *TLS(Thread-Local-Storage)* 이 어떤식으로 사용되는지, 주로 어떤 함수 및 프로퍼티를 이용하는지 배웠습니다. 전역 변수(Heap 영역)을 가져와 지역 변수(Stack 영역)처럼 이용, *Parallel.Invoke* 함수를 간략하게 써봤습니다. Task 클래스를 대신해서 간단하게 테스트 할 때 쓰면 좋을 것 같습니다. 
### 0118_네트워크 기초 이론, 통신 모델, 소켓 프로그래밍  
전체적으로 단번에 이해하기 힘든 강의였기에 코드를 따라 작성하고 되짚어가며 공부했습니다. 
### 0120_Listener, Session 1  
이해가 잘 안되는 부분이 많았습니다. 전에 작성한 소켓 프로그래밍 자료를 비동기 방식으로 재배치하는 작업을 했습니다. *SocketAsyncEventArgs.Completed* 를 이용했습니다.
### 0120_Session 2~4, Connector, TCP vs UDP 
전 강의에서 하던 세션 작업을 이어서 하였고 클라이언트 접속 시 발생하는 Connector 부분 인터페이스를 Listener와 거의 동일하게 맞춰주었습니다. 그리고 *TCP(Transmission Control Protocol)* 와 *UDP(User Datagram Protocol)* 가 어떤 의미인지 어떤 상황에 사용하는지 두 가지방법의 장점과 단점에 대해서 간략하게 배웠습니다. 먼저 TCP는 패킷을 전달하는데에 있어서 안전을 보장하지만 모든 부분을 검증하기 때문에 속도가 느리고 반대로 UDP 같은 경우에는 안전을 보장하지 않는 대신 속도가 TCP에 비해 빠릅니다. 또한 UDP를 TCP처럼 신뢰성을 가질 수 있도록 만든것이 *RUDP(Reliable UDP)* 입니다.  
### 0122_RecvBuffer, SendBuffer, PacketSession  
*RecieveBuffer*를 일일이 작성하지 않고 따로 클래스를 만들어 관리하도록 했고 *SendBuffer* 또한 동일하게 개편했습니다. SendBuffer의 경우 멀티쓰레드 환경에서 사용하기 때문에 이전에 배운 **ThreadLocal** 클래스를 이용해서 Stack 영역에서 활용할 수 있도록 처리했습니다.
