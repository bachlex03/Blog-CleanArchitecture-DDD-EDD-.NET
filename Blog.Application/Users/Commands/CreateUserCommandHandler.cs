
// using Blog.Application.Common.Interfaces.Auth;
// using Blog.Domain;
// using ErrorOr;
// using MediatR;

// namespace Blog.Application.Users.Commands
// {
//     public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<string>>
//     {
//         private readonly IJwtGenerator _jwtGenerator;
//         private readonly ICustomerRepository _customerRepository;
//         private readonly IAuthService _authService;

//         public CreateUserCommandHandler(IJwtGenerator jwtGenerator, ICustomerRepository customerRepository, IAuthService authService)
//         {
//             _jwtGenerator = jwtGenerator;
//             _customerRepository = customerRepository;
//             _authService = authService;
//         }

//         public async Task<ErrorOr<string>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
//         {


//             return "";
//         }
//     }
// }