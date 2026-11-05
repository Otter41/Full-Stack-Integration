# InventoryHub: Microsoft Copilot Reflection

## Integration and Debugging

I used Microsoft Copilot to help identify and resolve integration issues between my Blazor frontend and ASP.NET Core backend.

During debugging, I fixed a build error caused by a missing Blazor routing namespace. I then tested both applications and confirmed that the frontend could successfully retrieve and display products from the backend API.

## JSON Communication

I verified that the API returned structured JSON containing product names, prices, stock quantities, and nested category information.

I also confirmed that the frontend could deserialize and display this information correctly.

## Error Handling

I tested how the application behaved when the backend was unavailable. After stopping the API and refreshing the frontend, the application displayed an appropriate error message instead of crashing.

## Performance Optimization

The application uses server-side caching to reduce repeated processing of product data.

I measured ten API requests using PowerShell. The first request took approximately 136.63 ms, while the following nine averaged approximately 0.83 ms.

These results confirmed fast subsequent response times, although they do not establish how much improvement caching alone provided.

## Final Reflection

Microsoft Copilot assisted me with debugging and testing the integration between the frontend and backend. The process helped me better understand Blazor routing, API communication, JSON deserialization, error handling, and performance measurement.

After the fixes and tests, InventoryHub successfully displayed inventory information and handled server connection failures.
