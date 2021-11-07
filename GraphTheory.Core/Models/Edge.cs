namespace GraphTheory.Core.Models
{
    public class Edge
    {
        public Node NodeFrom { get; set; }

        public Node NodeTo { get; set; }

        public override bool Equals(object obj)
        {
            var edge = obj as Edge;
            if (edge == null)
                return false;

            if (this.NodeFrom == edge.NodeFrom && this.NodeTo == edge.NodeTo)
                return true;

            if (this.NodeFrom == edge.NodeTo && this.NodeTo == edge.NodeFrom)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
