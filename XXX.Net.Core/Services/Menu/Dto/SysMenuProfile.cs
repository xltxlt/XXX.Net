using XXX.Net.Core.Entity.Sys;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<SysMenu, SysMenuOutputDto>()
                .Map(
                dest => dest.Buttons,
                src => src.MenuButtons
                        .Where(x => x.ButtonType == 1)
                        .OrderBy(x => x.Sort)
                )
            .Map(
                dest => dest.TableButtons,
                src =>
                    src.MenuButtons
                        .Where(x => x.ButtonType == 2)
                        .OrderBy(x => x.Sort)
                )
            .Map(
                dest => dest.Fields,
                src =>
                    src.MenuFields
                        .OrderBy(x => x.Sort)
                );
            config.ForType<SysMenuButton, SysMenuTableButtonDto>();
            config.ForType<SysMenuField, SysMenuTableFieldDto>();
        }
    }
}
