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
    public class OSAndOSVersionTests
    {
        
        [Fact]
        public async void FullWorkflow()
        {
            // Initialize http client
            var client = new HttpClient();
            var controllerName = "Oses";
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
            var createDto = new OSCreateDto { Name = newName, Position = newPosition };
            // Send add request
            var responseAdd = await client.PostAsJsonAsync(addUrl, createDto);
            var createdDto = await responseAdd.Content.ReadFromJsonAsync<ServiceResponse<OSDto>>();
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
            var updateDto = new OSUpdateDto { Name = updatedName, Position = updatedPosition };
            var responseUpdate = await client.PutAsJsonAsync(updateUrl, updateDto);
            var updatedDto = await responseUpdate.Content.ReadFromJsonAsync<ServiceResponse<OSDto>>();
            Assert.NotNull(updatedDto);
            Assert.NotNull(updatedDto.Data);
            Assert.Equal(updatedName, updatedDto.Data.Name);
            Assert.Equal(updatedPosition, updatedDto.Data.Position);

            await TestOSVersionWorkflow(newId);

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

        private async Task TestOSVersionWorkflow(Guid osId)
        {
            // Initialize http client
            var client = new HttpClient();
            var controllerName = "OSVersions";
            var url = Common.BaseUrl + $"{controllerName}/GetAllByOS";

            // Send count request
            // Create list of os ids
            var osIdList = new List<Guid>();
            osIdList.Add(osId);
            var responseGetAll = await client.PostAsJsonAsync(url, osIdList);
            var getAllDto = await responseGetAll.Content.ReadFromJsonAsync<ServiceResponse<List<OSVersionDto>>>();
            Assert.NotNull(responseGetAll);
            Assert.NotNull(getAllDto);
            Assert.NotNull(getAllDto.Data);
            Assert.Equal(0, getAllDto.Data.Count);
            
            // Add
            var newName = Guid.NewGuid().ToString();
            var newPosition = 1;
            var addUrl = Common.BaseUrl + $"{controllerName}";
            var createDto = new OSVersionCreateDto { 
                Name = newName, Position = newPosition, OsId = osId };
            // Send add request
            var responseAdd = await client.PostAsJsonAsync(addUrl, createDto);
            var createdDto = await responseAdd.Content.ReadFromJsonAsync<ServiceResponse<OSVersionDto>>();
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
            var updateDto = new OSVersionUpdateDto { Name = updatedName, Position = updatedPosition };
            var responseUpdate = await client.PutAsJsonAsync(updateUrl, updateDto);
            var updatedDto = await responseUpdate.Content.ReadFromJsonAsync<ServiceResponse<OSVersionDto>>();
            Assert.NotNull(updatedDto);
            Assert.NotNull(updatedDto.Data);
            Assert.Equal(updatedName, updatedDto.Data.Name);
            Assert.Equal(updatedPosition, updatedDto.Data.Position);

            // After adding one OS Version, count should be 1
            responseGetAll = await client.PostAsJsonAsync(url, osIdList);
            getAllDto = await responseGetAll.Content.ReadFromJsonAsync<ServiceResponse<List<OSVersionDto>>>();
            Assert.NotNull(responseGetAll);
            Assert.NotNull(getAllDto);
            Assert.NotNull(getAllDto.Data);
            Assert.Equal(1, getAllDto.Data.Count);

            // Delete
            var deleteUrl = Common.BaseUrl + $"{controllerName}?id=" + newId;
            var responseDel = await client.DeleteAsync(deleteUrl);
            var delDto = await responseDel.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            Assert.NotNull(delDto);
            Assert.True(delDto.Data);

            
        }
    }
}