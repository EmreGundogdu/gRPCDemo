

using Grpc.Core;
using GrpcPopulation;

namespace gRPC.Demo.Server
{
    public class PopulationService : PopulationProvider.PopulationProviderBase
    {
        public override Task<populationResponse> GetPopulation(PopulationRequest populationRequest,ServerCallContext serverCallContext)
        {
            return Task.FromResult(new populationResponse { Count="1000"});
        }
    }
}
