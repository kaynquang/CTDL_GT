using System;

namespace Quang
{
    internal class ListSV
    {
        private NodeSV first;
        private NodeSV last;
        private int count;

        public int Count { get => count; set => count = value; }
        internal NodeSV First { get => first; set => first = value; }
        internal NodeSV Last { get => last; set => last = value; }

        public ListSV()
        {
            first = null;
            last = null;
            count = 0;
        }

        public bool IsEmpty() => first == null;

        public void RemoveFirst()
        {
            if (!IsEmpty())
            {
                NodeSV pDel = first;
                first = first.Next;
                pDel.Next = null;
                pDel = null;
                count--;
            }
        }

        public void RemoveLast()
        {
            if (!IsEmpty())
            {
                if (first == last)
                {
                    first = last = null;
                }
                else
                {
                    NodeSV pPre = first;
                    while (pPre.Next != last)
                        pPre = pPre.Next;
                    last = pPre;
                    last.Next = null;
                }
                count--;
            }
        }

        public void RemoveAny(NodeSV pDel)
        {
            if (pDel.Next != null)
            {
                pDel.Data = pDel.Next.Data;
                NodeSV temp = pDel.Next;
                pDel.Next = pDel.Next.Next;
                temp = null;
                count--;
            }
        }

        public NodeSV SearchX(int x)
        {
            NodeSV p = first;
            while (p != null)
            {
                if (p.Data.MaSo == x)
                    return p;
                p = p.Next;
            }
            return null;
        }

        public bool RemoveByMaSo(int maSo)
        {
            if (IsEmpty()) return false;

            NodeSV pDel = SearchX(maSo);
            if (pDel != null)
            {
                RemoveAny(pDel);
                return true;
            }

            return false;
        }

        public void AddAfterP(NodeSV p, NodeSV newNode)
        {
            newNode.Next = p.Next;
            p.Next = newNode;
            count++;
        }

        public void AddFirst(NodeSV newNode)
        {
            if (IsEmpty())
                first = last = newNode;
            else
            {
                newNode.Next = first;
                first = newNode;
            }
            count++;
        }

        public void AddLast(NodeSV newNode)
        {
            if (IsEmpty())
                first = last = newNode;
            else
            {
                last.Next = newNode;
                last = newNode;
            }
            count++;
        }

        public void AddAsc(NodeSV newNode)
        {
            if (IsEmpty())
                first = last = newNode;
            else if (newNode.Data.MaSo <= first.Data.MaSo)
            {
                AddFirst(newNode);
            }
            else
            {
                NodeSV current = first;
                while (current.Next != null && current.Next.Data.MaSo < newNode.Data.MaSo)
                {
                    current = current.Next;
                }

                if (current.Next == null)
                    AddLast(newNode);
                else
                    AddAfterP(current, newNode);
            }
            count++;
        }

        public void SortByMaSo()
        {
            if (IsEmpty()) return;

            NodeSV i = first;
            while (i != null)
            {
                NodeSV j = i.Next;
                while (j != null)
                {
                    if (i.Data.MaSo > j.Data.MaSo)
                    {
                        SinhVien temp = i.Data;
                        i.Data = j.Data;
                        j.Data = temp;
                    }
                    j = j.Next;
                }
                i = i.Next;
            }
        }
    }
}
