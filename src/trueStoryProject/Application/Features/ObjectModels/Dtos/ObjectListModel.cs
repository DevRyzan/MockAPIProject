
using Core.Persistence.Paging;

namespace Application.Features.ObjectModels.Dtos;

public class ObjectListModel:BasePageableModel
{
    public IList<ObjectListDto> Items { get; set; }

}
