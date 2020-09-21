using System;

namespace GameUtils {
    public static class GRandom {
        private static Random rand;
        
        public static int Next(int value) {
            if (rand == null) {
                rand = new Random();
            }
            return rand.Next(value);
        }
    }
}