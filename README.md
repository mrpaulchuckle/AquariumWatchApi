
# AquariumWatch

This API provides data access for the AquariumWatch app, an application that allows configuration and data management of aquariums.




## API Reference

#### Get all aquariums

```http
  GET /aquariums
```

#### Create aquarium

```http
  POST /aquariums
```

The following properties should be passed as the request body:

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `name`      | `string` | **Required**. Name of Aquarium to create. |
| `description`      | `string` | **Required**. Description of Aquarium to create. |
| `type`      | `AquariumType enum` | **Required**. Type of Aquarium. Can be Cold, Marine or Tropical. |

#### Get aquarium by id

```http
  GET /aquariums/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of aquarium to fetch |

#### Delete aquarium

```http
  DELETE /aquariums/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of aquarium to delete |







## Database Changes

### Create EF migration
dotnet ef migrations add [MigrationName] --project AquariumWatch.Data --startup-project AquariumWatch.Api

### Update database 
dotnet ef database update --verbose --project AquariumWatch.Data   --startup-project AquariumWatch.Api