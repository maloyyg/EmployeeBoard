using AutoMapper;
using EmployeeBoard.DataModel;
using EmployeeBoard.DTO;

namespace EmployeeBoard.Services
{
    public class MapperConfig
    {
        public static IMapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<AddEmployeeDTO,Employee>();
                cfg.CreateMap<UpdateEmployeeDTO, Employee>();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
