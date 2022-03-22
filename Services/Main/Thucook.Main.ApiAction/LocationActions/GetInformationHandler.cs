using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thucook.EntityFramework;
using Thucook.Main.ApiModel;
using Thucook.Main.ApiModel.ApiInputModels;
using Thucook.Main.ApiModel.ApiReponseModels;

namespace Thucook.Main.ApiAction.LocationActions
{
    public class GetInformationHandler : IRequestHandler<ApiActionLocationRequest<LocationGetInfoInputModel>, IApiResponse>
    {
        private readonly ThucookContext _dbContext;

        public GetInformationHandler(ThucookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IApiResponse> Handle(ApiActionLocationRequest<LocationGetInfoInputModel> request, CancellationToken cancellationToken)
        {
            var location = await (from l in _dbContext.Locations
                                  where
                                  l.LocationId == request.LocationId
                                  select l).FirstOrDefaultAsync(cancellationToken);

            return ApiResponse.CreateModel(new LocationInfoResponseModel
            {
                LocationId = request.LocationId,
                LocationName = location.LocationName
            });
        }
    }
}
