using CENAOAPI.Models;
using CENAODB.DataBase;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
namespace CENAOAPI.Services
{
    public class AutenticacionServices
    {
        public AutenticacionServices()
        {
            encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            validator = new JwtValidator(serializer, provider);
            decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
        }
        const string secret = "BfFbUBWEBRWUxLmzN6CI0sNTkliLbMbzo%LEmZ}@y[.wMv)`lNjOFxUBfFlNjOFxU";

        IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
        IJsonSerializer serializer = new JsonNetSerializer();
        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        IDateTimeProvider provider = new UtcDateTimeProvider();
        IJwtValidator validator;
        IJwtDecoder decoder;
        IJwtEncoder encoder;

       /* public AuthenticationResponse Authentication(string usuario)
        {
            using (var db = new CarCityDBEntities())
            {
               var usuarioDB = db.tbUsuarios.Where(x => x.codigoUsuario == usuario).FirstOrDefault();
                var token = encoder.Encode(new InicioSesionViewModel
                {
                    id = usuarioDB.idUsuario,
                    usuario = usuarioDB.codigoUsuario,
                    esActivo = usuarioDB.esActivo,
                    FechaFin = DateTime.Now.AddHours(12)
                }, secret);
                
                return new AuthenticationResponse { Message = "Ok", id= usuarioDB.idUsuario, usuario = usuarioDB.codigoUsuario, esActivo= usuarioDB.esActivo, Token = token };
            }
        }*/

        public InicioSesionViewModel Validate(string token)
        {
            return decoder.DecodeToObject<InicioSesionViewModel>(token);
        }
    }
}