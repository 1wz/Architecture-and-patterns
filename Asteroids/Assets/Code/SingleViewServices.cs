using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

namespace ObjectPool
{
    internal static class SingleViewServices
    {
        private static ViewServices viewServices;
        public static ViewServices ViewServices
        {
            get
            {
                if (viewServices == null) viewServices = new ViewServices();
                return viewServices;
            }
        }
    }
}