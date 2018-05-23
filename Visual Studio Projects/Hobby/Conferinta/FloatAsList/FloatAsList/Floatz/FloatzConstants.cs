namespace FloatAsList
{
    public partial class Floatz
    {
        public static class Constants
        {
            public static Floatz ZERO(char separator=',') { return new Floatz(); }
            public static Floatz ONE(char separator=',') { return new Floatz("1"); }
            public static Floatz TWO(char separator=',') { return new Floatz("2"); }
            public static Floatz PI(char separator=',') { return new Floatz("3"+separator+"14159265358979323846264338327950"); }
            public static Floatz SQRT2(char separator=','){ return new Floatz("1" + separator + "41421356237309504880168872420969"); }
            public static Floatz E(char separator=',') { return new Floatz("2" + separator + "71828182845904523536028747135266"); }
            public static Floatz E_CONSTANT(char separator=',') { return new Floatz("0" + separator + "57721566490153286060651209008240"); }
            public static Floatz GOLDEN_RATIO(char separator=',') { return new Floatz("1" + separator + "61803398874989484820458683436563"); }
            public static Floatz CONWAY(char separator=',') { return new Floatz("1" + separator + "30357726903429639125709911215255"); }
            public static Floatz FEIGENBAUM_ALPHA(char separator=',') { return new Floatz("2" + separator + "50290787509589282228390287321821"); }
            public static Floatz SqrtTreshold(char separator=',') { return new Floatz("0" + separator + "0000000000000000000000000000001"); }
        }
    }
}
