using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using unirest_net.http;

namespace MvcApi.Services
{
    public class I33tsp34kService
    {   
        public string CallWebApi(string StrIn, string callMode)
        {
            HttpResponse<string> jsonResponse = null;
            switch(callMode)
            {
                case ("encode"):
                    jsonResponse = Unirest.get("https://montanaflynn-l33t-sp34k.p.mashape.com/encode?text=" + StrIn)
                        .header("accept", "application/json")
                        .header("X-Mashape-Authorization", "pWTShfLsteDVCAuvkQQb4iVSRpTxV2et")
                        //.field("text", StrIn) 
                        .asJson<string>();
                    break;                
                case ("decode"):
                    jsonResponse = Unirest.get("https://montanaflynn-l33t-sp34k.p.mashape.com/decode?text=" + StrIn)
                        .header("accept", "application/json")
                        .header("X-Mashape-Authorization", "pWTShfLsteDVCAuvkQQb4iVSRpTxV2et")
                        //.field("text", StrIn) 
                        .asJson<string>();
                    break;               
            }
            return jsonResponse.Body;

        }

        
       
    }


   
}