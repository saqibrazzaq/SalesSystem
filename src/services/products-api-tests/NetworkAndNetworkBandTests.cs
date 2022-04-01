using products_api.Dtos;
using products_api.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace products_api_tests
{
    public class NetworkAndNetworkBandTests
    {
        
        [Fact]
        public async void FullWorkflow()
        {
            // Initialize http client
            var client = new HttpClient();
            var controllerName = "Networks";
            var url = Common.BaseUrl + $"{controllerName}/count";

            // Send count request
            var responseCount = await client.GetFromJsonAsync<ServiceResponse<int>>(
                url);
            Assert.NotNull(responseCount);
            // Save count
            var countBeforeInsert = responseCount.Data;

            // Add
            var newName = Guid.NewGuid().ToString();
            var newPosition = 1;
            var addUrl = Common.BaseUrl + $"{controllerName}";
            var createDto = new NetworkCreateDto { Name = newName, Position = newPosition };
            // Send add request
            var responseAdd = await client.PostAsJsonAsync(addUrl, createDto);
            var createdDto = await responseAdd.Content.ReadFromJsonAsync<ServiceResponse<NetworkDto>>();
            Assert.NotNull(responseAdd);
            Assert.NotNull(createdDto);
            Assert.NotNull(createdDto.Data);
            Assert.Equal(createdDto.Data.Name, newName);
            Assert.Equal(createdDto.Data.Position, newPosition);

            // Update
            var newId = createdDto.Data.Id;
            var updateUrl = Common.BaseUrl + $"{controllerName}?id=" + newId;
            var updatedName = createdDto.Data.Name + "-updated";
            var updatedPosition = createdDto.Data.Position + 3;
            var updateDto = new NetworkUpdateDto { Name = updatedName, Position = updatedPosition };
            var responseUpdate = await client.PutAsJsonAsync(updateUrl, updateDto);
            var updatedDto = await responseUpdate.Content.ReadFromJsonAsync<ServiceResponse<NetworkDto>>();
            Assert.NotNull(updatedDto);
            Assert.NotNull(updatedDto.Data);
            Assert.Equal(updatedName, updatedDto.Data.Name);
            Assert.Equal(updatedPosition, updatedDto.Data.Position);

            await TestNetworkBandWorkflow(newId);

            // Delete
            var deleteUrl = Common.BaseUrl + $"{controllerName}?id=" + newId;
            var responseDel = await client.DeleteAsync(deleteUrl);
            var delDto = await responseDel.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            Assert.NotNull(delDto);
            Assert.True(delDto.Data);

            // Count again
            responseCount = await client.GetFromJsonAsync<ServiceResponse<int>>(
                url);
            Assert.NotNull(responseCount);
            // Save count
            var countAfterInsert = responseCount.Data;
            Assert.Equal(countBeforeInsert, countAfterInsert);
        }

        private async Task TestNetworkBandWorkflow(Guid networkId)
        {
            // Initialize http client
            var client = new HttpClient();
            var controllerName = "NetworkBands";
            var url = Common.BaseUrl + $"{controllerName}/count?networkId={networkId}";

            // Send count request
            var responseCount = await client.GetFromJsonAsync<ServiceResponse<int>>(
                url);
            Assert.NotNull(responseCount);
            // Save count
            var countBeforeInsert = responseCount.Data;

            // Add
            var newName = Guid.NewGuid().ToString();
            var newPosition = 1;
            var addUrl = Common.BaseUrl + $"{controllerName}";
            var createDto = new NetworkBandCreateDto { 
                Name = newName, Position = newPosition, NetworkId = networkId };
            // Send add request
            var responseAdd = await client.PostAsJsonAsync(addUrl, createDto);
            var createdDto = await responseAdd.Content.ReadFromJsonAsync<ServiceResponse<NetworkBandDto>>();
            Assert.NotNull(responseAdd);
            Assert.NotNull(createdDto);
            Assert.NotNull(createdDto.Data);
            Assert.Equal(createdDto.Data.Name, newName);
            Assert.Equal(createdDto.Data.Position, newPosition);

            // Update
            var newId = createdDto.Data.Id;
            var updateUrl = Common.BaseUrl + $"{controllerName}?id=" + newId;
            var updatedName = createdDto.Data.Name + "-updated";
            var updatedPosition = createdDto.Data.Position + 3;
            var updateDto = new NetworkBandUpdateDto { Name = updatedName, Position = updatedPosition };
            var responseUpdate = await client.PutAsJsonAsync(updateUrl, updateDto);
            var updatedDto = await responseUpdate.Content.ReadFromJsonAsync<ServiceResponse<NetworkBandDto>>();
            Assert.NotNull(updatedDto);
            Assert.NotNull(updatedDto.Data);
            Assert.Equal(updatedName, updatedDto.Data.Name);
            Assert.Equal(updatedPosition, updatedDto.Data.Position);

            // Delete
            var deleteUrl = Common.BaseUrl + $"{controllerName}?id=" + newId;
            var responseDel = await client.DeleteAsync(deleteUrl);
            var delDto = await responseDel.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            Assert.NotNull(delDto);
            Assert.True(delDto.Data);

            // Count again
            responseCount = await client.GetFromJsonAsync<ServiceResponse<int>>(
                url);
            Assert.NotNull(responseCount);
            // Save count
            var countAfterInsert = responseCount.Data;
            Assert.Equal(countBeforeInsert, countAfterInsert);
        }
    }
}