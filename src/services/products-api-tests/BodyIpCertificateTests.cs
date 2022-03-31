using products_api.Dtos;
using products_api.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using Xunit;

namespace products_api_tests
{
    public class BodyIpCertificateTests
    {
        
        [Fact]
        public async void FullWorkflow()
        {
            // Initialize http client
            var client = new HttpClient();
            var url = Common.BaseUrl + "BodyIpCertificates/count";

            // Send count request
            var responseCount = await client.GetFromJsonAsync<ServiceResponse<int>>(
                url);
            Assert.NotNull(responseCount);
            // Save count
            var countBeforeInsert = responseCount.Data;

            // Add
            var newName = Guid.NewGuid().ToString();
            var newPosition = 1;
            var addUrl = Common.BaseUrl + "BodyIpCertificates";
            var createDto = new BodyIpCertificateCreateDto { Name = newName, Position = newPosition };
            // Send add request
            var responseAdd = await client.PostAsJsonAsync(addUrl, createDto);
            var createdDto = await responseAdd.Content.ReadFromJsonAsync<ServiceResponse<BodyIpCertificateDto>>();
            Assert.NotNull(responseAdd);
            Assert.NotNull(createdDto);
            Assert.NotNull(createdDto.Data);
            Assert.Equal(createdDto.Data.Name, newName);
            Assert.Equal(createdDto.Data.Position, newPosition);

            // Update
            var newId = createdDto.Data.Id;
            var updateUrl = Common.BaseUrl + "BodyIpCertificates?id=" + newId;
            var updatedName = createdDto.Data.Name + "-updated";
            var updatedPosition = createdDto.Data.Position + 3;
            var updateDto = new BodyIpCertificateUpdateDto { Name = updatedName, Position = updatedPosition };
            var responseUpdate = await client.PutAsJsonAsync(updateUrl, updateDto);
            var updatedDto = await responseUpdate.Content.ReadFromJsonAsync<ServiceResponse<BodyIpCertificateDto>>();
            Assert.NotNull(updatedDto);
            Assert.NotNull(updatedDto.Data);
            Assert.Equal(updatedName, updatedDto.Data.Name);
            Assert.Equal(updatedPosition, updatedDto.Data.Position);

            // Delete
            var deleteUrl = Common.BaseUrl + "BodyIpCertificates?id=" + newId;
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