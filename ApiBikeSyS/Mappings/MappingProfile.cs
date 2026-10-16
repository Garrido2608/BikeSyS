using ApiBikeSyS.DTOs.Bicicleta;
using ApiBikeSyS.DTOs.Cliente;
using ApiBikeSyS.DTOs.Estado;
using ApiBikeSyS.DTOs.HistorialEstado;
using ApiBikeSyS.DTOs.Localidad;
using ApiBikeSyS.DTOs.Marca;
using ApiBikeSyS.DTOs.Modelo;
using ApiBikeSyS.DTOs.OrdenService;
using ApiBikeSyS.DTOs.Provincia;
using ApiBikeSyS.DTOs.Repuesto;
using ApiBikeSyS.DTOs.RepuestoUsado;
using ApiBikeSyS.DTOs.Servicio;
using ApiBikeSyS.DTOs.TipoRueda;
using ApiBikeSyS.DTOs.TipoServicio;
using ApiBikeSyS.DTOs.Usuario;
using ApiBikeSyS.Models;
using AutoMapper;

namespace ApiBikeSyS.Mappings

{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //  Provincia
            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<CrearProvinciaDTO, Provincia>();
            CreateMap<ActualizarProvinciaDTO, Provincia>();

            //  Localidad
            CreateMap<Localidad, LocalidadDTO>();
            CreateMap<CrearLocalidadDTO, Localidad>();
            CreateMap<ActualizarLocalidadDTO, Localidad>();

            //  Marca
            CreateMap<Marca, MarcaDTO>();
            CreateMap<CrearMarcaDTO, Marca>();
            CreateMap<ActualizarMarcaDTO, Marca>();

            //  Modelo
            CreateMap<Modelo, ModeloDTO>();
            CreateMap<CrearModeloDTO, Modelo>();
            CreateMap<ActualizarModeloDTO, Modelo>();

            //  TipoRueda
            CreateMap<TipoRueda, TipoRuedaDTO>();
            CreateMap<CrearTipoRuedaDTO, TipoRueda>();
            CreateMap<ActualizarTipoRuedaDTO, TipoRueda>();

            //  Estado
            CreateMap<Estado, EstadoDTO>();
            CreateMap<CrearEstadoDTO, Estado>();
            CreateMap<ActualizarEstadoDTO, Estado>();

            //  TipoServicio
            CreateMap<TipoServicio, TipoServicioDTO>();
            CreateMap<CrearTipoServicioDTO, TipoServicio>();
            CreateMap<ActualizarTipoServicioDTO, TipoServicio>();

            //  Repuesto
            CreateMap<Repuesto, RepuestoDTO>();
            CreateMap<CrearRepuestoDTO, Repuesto>();
            CreateMap<ActualizarRepuestoDTO, Repuesto>();

            //  Usuario
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<CrearUsuarioDTO, Usuario>();
            CreateMap<ActualizarUsuarioDTO, Usuario>();

            //  Cliente
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<CrearClienteDTO, Cliente>();
            CreateMap<ActualizarClienteDTO, Cliente>();

            //  Bicicleta
            CreateMap<Bicicleta, BicicletaDTO>();
            CreateMap<CrearBicicletaDTO, Bicicleta>();
            CreateMap<ActualizarBicicletaDTO, Bicicleta>();

            //  OrdenService
            CreateMap<OrdenService, OrdenServiceDTO>();
            CreateMap<CrearOrdenServiceDTO, OrdenService>();
            CreateMap<ActualizarOrdenServiceDTO, OrdenService>();

            //  HistorialEstado
            CreateMap<HistorialEstado, HistorialEstadoDTO>();
            CreateMap<CrearHistorialEstadoDTO, HistorialEstado>();
            CreateMap<ActualizarHistorialEstadoDTO, HistorialEstado>();

            //  RepuestoUsado
            CreateMap<RepuestoUsado, RepuestoUsadoDTO>();
            CreateMap<CrearRepuestoUsadoDTO, RepuestoUsado>();
            CreateMap<ActualizarRepuestoUsadoDTO, RepuestoUsado>();

            //  Servicio
            CreateMap<Servicio, ServicioDTO>();
            CreateMap<CrearServicioDTO, Servicio>();
            CreateMap<ActualizarServicioDTO, Servicio>();
        }
    }
}