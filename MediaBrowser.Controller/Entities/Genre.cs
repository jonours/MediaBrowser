﻿using System.Runtime.Serialization;
using MediaBrowser.Controller.Entities.Audio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaBrowser.Controller.Entities
{
    /// <summary>
    /// Class Genre
    /// </summary>
    public class Genre : BaseItem, IItemByName
    {
        /// <summary>
        /// Gets the user data key.
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string CreateUserDataKey()
        {
            return "Genre-" + Name;
        }

        /// <summary>
        /// Returns the folder containing the item.
        /// If the item is a folder, it returns the folder itself
        /// </summary>
        /// <value>The containing folder path.</value>
        [IgnoreDataMember]
        public override string ContainingFolderPath
        {
            get
            {
                return Path;
            }
        }

        public override bool CanDelete()
        {
            return false;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is owned item.
        /// </summary>
        /// <value><c>true</c> if this instance is owned item; otherwise, <c>false</c>.</value>
        [IgnoreDataMember]
        public override bool IsOwnedItem
        {
            get
            {
                return false;
            }
        }

        public IEnumerable<BaseItem> GetTaggedItems(IEnumerable<BaseItem> inputItems)
        {
            return inputItems.Where(GetItemFilter());
        }

        public Func<BaseItem, bool> GetItemFilter()
        {
            return i => !(i is Game) && !(i is IHasMusicGenres) && i.Genres.Contains(Name, StringComparer.OrdinalIgnoreCase);
        }
    }
}
