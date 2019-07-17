using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiChat.Data 
{
  public enum ShortMessageStatus
  {
    Unknown = 1,
		Requested = 2,
		Received = 3,
		Sent = 4,
		Delivered = 5,
		Not_Delivered = 6
  }
}

