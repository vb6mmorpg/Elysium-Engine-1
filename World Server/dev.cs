using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldServer {
    class dev {

       int[][] _map = new int[100][];
      
       private void Test() {
            var result = 0;

            for (int i = 0; i < _map.Length; i++) {
                for (int n = 0; n < _map.Length; n++) {
                    if (_map[i][n] > 0) {
                        result++;
                    }
                }
            }
        }

        




    }
}
