namespace AppSamuraiAds.Api
{
    public class AdSize
    {
        private bool isSmartBanner;
        private int width;
        private int height;

        public static readonly AdSize Banner = new AdSize(320, 50);
        public static readonly AdSize MediumRectangle = new AdSize(300, 250);
        public static readonly AdSize IABBanner = new AdSize(468, 60);
        public static readonly AdSize Leaderboard = new AdSize(728, 90);
        public static readonly AdSize SmartBanner = new AdSize(true);
        public static readonly int FullWidth = -1;

        public AdSize(int width, int height)
        {
            isSmartBanner = false;
            this.width = width;
            this.height = height;
        }

        private AdSize(bool isSmartBanner) : this(0, 0)
        {
            this.isSmartBanner = isSmartBanner;
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public bool IsSmartBanner
        {
            get
            {
                return isSmartBanner;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            AdSize other = (AdSize)obj;
            return (width == other.width) && (height == other.height) && (isSmartBanner == other.isSmartBanner);
        }

        public static bool operator ==(AdSize a, AdSize b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(AdSize a, AdSize b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            int hashBase = 71;
            int hashMultiplier = 11;

            int hash = hashBase;
            hash = (hash * hashMultiplier) ^ width.GetHashCode();
            hash = (hash * hashMultiplier) ^ height.GetHashCode();
            hash = (hash * hashMultiplier) ^ isSmartBanner.GetHashCode();
            return hash;
        }
    }
}