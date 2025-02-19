﻿using Newtonsoft.Json;

namespace Core_API.Models
{
  public class PlaceholderUserModel
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Address? Address { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public Company? Company { get; set; }
  }

  #region SubModels
  [JsonObject(ItemNullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
  public class Address
  {
    public string Street { get; set; } = string.Empty;
    public string Suite { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Zipcode { get; set; } = string.Empty;
    public Geo Geo { get; set; }
  }

  public class Geo
  {
    public string Lat { get; set; } = string.Empty;
    public string Lng { get; set; } = string.Empty;
  }

  public class Company
  {
    public string Name { get; set; } = string.Empty;
    public string CatchPhrase { get; set; } = string.Empty;
    public string BS { get; set; } = string.Empty;
  }
  #endregion
}