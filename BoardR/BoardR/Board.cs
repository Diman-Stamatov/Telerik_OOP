﻿using BoardR.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BoardR.Tests")]
namespace BoardR
{
    internal static class Board 
    {
        

        private static List<BoardItem> items;
        public static int TotalItems
        {
            get
            {
                return items.Count;
            }
        
        }
        static Board()
        {
            items = new List<BoardItem>();
        }

        public static void AddItem(BoardItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(null, "The item you are trying to add is empty!");
            }
            for (int itemIndex = 0; itemIndex < TotalItems; itemIndex++)
            {
                var currentItem = items[itemIndex];
                if (currentItem.Equals(item) == true)
                {
                    throw new InvalidOperationException("The item you are trying to add already exists!");

                }
            }
            
            items.Add(item);
        }
        public static void LogHistory(ILogger logger)
        {
            var fullHistory = new StringBuilder();
            foreach (var boardItem in items)
            {
                fullHistory.AppendLine(boardItem.ViewHistory());
            }
            logger.Log(fullHistory.ToString());
        }

        
    }
}
