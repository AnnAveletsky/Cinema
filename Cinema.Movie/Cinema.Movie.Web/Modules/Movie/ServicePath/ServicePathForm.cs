
namespace Cinema.Movie.Movie.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Movie.ServicePath")]
    [BasedOnRow(typeof(Entities.ServicePathRow))]
    public class ServicePathForm
    {
        public String Path { get; set; }
        public Int16 ServiceId { get; set; }
    }
}