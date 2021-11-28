namespace GraphTheory.Core.Models
{
    public class Edge
    {
        public Node Source { get; set; }

        public Node Destination { get; set; }

        public int Weight { get; set; }

        public override bool Equals(object obj)
        {
            var edge = obj as Edge;
            if (edge == null)
                return false;

            if (this.Source == edge.Source && this.Destination == edge.Destination)
                return true;

            if (this.Source == edge.Destination && this.Destination == edge.Source)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
