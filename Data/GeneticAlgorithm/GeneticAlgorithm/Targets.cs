using System;

namespace GeneticAlgorithm
{
    public static class Targets
    {
        public static int GetTargetEquationA(GeneticValue value)
        {
            var (x, y, z, u, w) = (value.X, value.Y, value.Z, value.U, value.W);
            return Math.Abs(y + u*w*(x*x)*y + 2*u*w*x*z + (w*w)*x*z - 40);
        }
        
        public static int GetTargetEquationB(GeneticValue value)
        {
            var (x, y, z, u, w) = (value.X, value.Y, value.Z, value.U, value.W);
            return Math.Abs(w*(x*x)*(y*y) + z + w*(x*x)*z + u*x*(y*y)*z + u*(w*w)*(x*x)*(z*z) + 50);
        }
    }
}