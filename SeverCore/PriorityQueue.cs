using System;
using System.Collections.Generic;

namespace ServerCore
{
    // 자기 자신을 비교할 수 있는(IComparable<T>) 클래스만 제너릭 형식에 포함가능
    public class PriorityQueue<T> where T : IComparable<T>
    {
        // 제너릭을 받는 리스트 생성
        List<T> _heap = new List<T>();

        public int Count { get { return _heap.Count; } }

        // O(LogN)
        public void Push(T data)
        {
            // 힙의 맨 끝에 새로운 데이터를 삽입한다.
            _heap.Add(data);

            int now = _heap.Count - 1;

            // 리스트 인덱스가 0보다 크면 반복
            while (now > 0)
            {
                // _heap[now] 와 _heap[next]의 비교값이 0보다 작으면 반복 취소
                // 그러니까 now 인덱스에서 이미 우선순위가 결정되어있는 상태라면 반복문을 빠져나간다는 소리.
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                // 두 값을 교체한다.
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치를 이동한다.
                now = next;
            }
        }

        // O(LogN)
        public T Pop()
        {
            // 반환할 데이터를 저장
            T ret = _heap[0];

            // 마지막 데이터를 root로 이동
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // 역으로 내려가는 도장깨기
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;

                // 왼쪽 값이 현재 값보다 크면 왼쪽으로 이동
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                // 오른쪽 값이 현재(왼쪽 이동 포함) 값보다 크면 오른쪽으로 이동
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                // 왼쪽, 오른쪽 모두 현재값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값을 교체한다.
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치로 이동한다.
                now = next;
            }

            return ret;
        }

        public T Peek()
        {
            if (_heap.Count == 0)
                return default(T);

            return _heap[0];
        }
    }
}
