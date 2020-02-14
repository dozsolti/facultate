//Problema 2:

public float Fadec(){
	public List<Muchie> muchii = new List<Muchie>();
	for(int i=0;i<n;i++)
		for(int j=i;j<n;j++)
			Muchii.Add(new Muchie(x[i],x[j]);
	int s = 0;
	for(int i=0;i<Muchii.Count;i++)
		for(int j=i;j<Muchii.Count;j++)		
			if(SeIntersecteaza(Muchii[i].s, Muchii[i].e, Muchii[j].s,Muchii[i].e)
				s++;
	return s;
}


public bool SeIntersecteaza(Point l1P1, Point l1P2, Point l2P1, Point l2P2)
        {

            double A1 = l1P2.Y - l1P1.Y;
            double B1 = l1P1.X - l2P2.X;
            double C1 = A1 * l1P1.X + B1 * l1P1.Y;

            double A2 = l2P2.Y - l2P1.Y;
            double B2 = l2P1.X - l2P2.X;
            double C2 = A2 * l2P1.X + B2 * l2P1.Y;

            double det = A1 * B2 - A2 * B1;
            if (det != 0)
            {
                double x = (B2 * C1 - B1 * C2) / det;
                double y = (A1 * C2 - A2 * C1) / det;

                return (Math.Min(l1P1.X, l1P2.X) < x &&
                Math.Max(l1P1.X, l1P2.X) > x &&
                Math.Min(l1P1.Y, l1P2.Y) < y &&
                Math.Max(l1P1.Y, l1P2.Y) > y &&
                Math.Min(l2P1.X, l2P2.X) < x &&
                Math.Max(l2P1.X, l2P2.X) > x &&
                Math.Min(l2P1.Y, l2P2.Y) < y &&
                Math.Max(l2P1.Y, l2P2.Y) > y);

            }
        }