﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.HelperControls
{
    class ListViewGrouping<K,T> : Collection<T>
    {
        public K Key { get; private set; }
        public ListViewGrouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }
    }
}
