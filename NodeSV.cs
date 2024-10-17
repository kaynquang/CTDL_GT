namespace Quang
{
    internal class NodeSV
    {
        SinhVien data;
        NodeSV next;

        public NodeSV() { }

        public NodeSV(SinhVien data)
        {
            this.data = data;
            this.next = null;
        }

        internal SinhVien Data { get => data; set => data = value; }
        internal NodeSV Next { get => next; set => next = value; }
    }
}
