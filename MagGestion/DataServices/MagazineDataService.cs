﻿using MagGestion.DataServices.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Magazine;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagGestion.DataServices
{
    public class MagazineDataService : BaseClient
    {
        public MagazineDataService (ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger) : base(cache, serializer, errorLogger)
        {
            BaseUrl = new Uri(BaseUrl, Constant.MagazineUrl);
        }

        public List<DGVMagazine> GetMagazines()
        {
            RestRequest request = new RestRequest() { Method = Method.GET };
            request.AddHeader("content-type", "application/json");
            return Get<List<DGVMagazine>>(request);
        }

        public Magazine GetMagazine(int id)
        {
            RestRequest request = new RestRequest($"{id}") { Method = Method.GET };
            return Get<Magazine>(request);
        }

        public bool PutMagazine(Magazine mag)
        {
            RestRequest request = new RestRequest($"{mag.Id}") { Method = Method.PUT };
    //        request.AddHeader("Content-Type", "multipart/form-data");
            request.AddJsonBody(mag);
      //      request.AddFile("image", mag.imageUrl);
            return Execute(request).StatusCode == System.Net.HttpStatusCode.NoContent ? true : false;
        }

        public bool PostMagazine(Magazine mag)
        {
            RestRequest request = new RestRequest { Method = Method.POST };
            request.AddJsonBody(mag);
            return Execute(request).StatusCode == System.Net.HttpStatusCode.Created ? true : false;
        }
    }
}
