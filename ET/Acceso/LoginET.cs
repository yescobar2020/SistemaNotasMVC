

using System.Collections.Generic;

namespace ET.Acceso
{

    public class ListLoginET : List<LoginET> {}

   public class LoginET
    {
        public int LGId { get; set; }
        public string LGUsuario { get; set; }
        public string LGContraseña { get; set; }

    }
}
