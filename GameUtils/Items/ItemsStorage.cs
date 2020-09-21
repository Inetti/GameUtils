using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace GameUtils.Items {
    public class ItemsStorage<T> where T : IItem {
        private class StorageData<T1> where T1 : IItem {
            public T1 item;
            public int count;

            public StorageData(T1 item, int amount) {
                this.item = item;
                count = amount;
            }
        }

        public int Size { get; private set; }
        public int FreeSpace { get; private set; }
        public bool IsFull { get { return FreeSpace == 0; } }
        
        private readonly Dictionary<string, StorageData<T>> items;

        #region CONSTRUCTORS
        public ItemsStorage() : this(Int32.MaxValue) {}

        public ItemsStorage(int size) {
            Size      = size;
            FreeSpace = size;
            items     = new Dictionary<string, StorageData<T>>();
        }
        #endregion
        
        public bool AddItem(T item, int amount) {
            if (FreeSpace >= amount * item.Size) {
                FreeSpace -= amount * item.Size;
                if (items.ContainsKey(item.Name)) {
                    items[item.Name].count += amount;
                    return true;
                }
                items.Add(item.Name, new StorageData<T>(item, amount));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Return a items list with required size or a list all items if the number of objects is less than the required number
        /// </summary>
        public T[] GetItems(string itemName, int amount) {
            int itemCount = ItemCount(itemName) < amount ? 0 : amount;
            T[] itemList = new T[itemCount];
            for (int i = 0; i < itemCount; i++) {
                T item = (T)Peek(itemName);
                itemList[i] = item;
                FreeSpace += item.Size;
                items[itemName].count -= 1;
                if (items[itemName].count  <= 0) {
                    items.Remove(itemName);
                }
            }
            return itemList;
        }
        
        public int ItemCount(string itemName) {
            if (Contains(itemName)) {
                return items[itemName].count;
            }
            return 0;
        }
        
        public bool Contains(string itemName) {
            return items.ContainsKey(itemName);
        }
        
        private T Peek(string itemName) {
            if (items.ContainsKey(itemName)) {
                return items[itemName].item;
            }
            return default(T);
        }

        public string[] GetListOfItemNames() {
            return items.Keys.ToArray();
        }
        
        public void UpSize(int amount) {
            Size += amount;
            FreeSpace += amount;
        }
    }
}