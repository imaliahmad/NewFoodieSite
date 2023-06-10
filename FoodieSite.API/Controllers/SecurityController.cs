using FoodieSite.API.DTOs.Request;
using FoodieSite.API.DTOs.Response;
using FoodieSite.CQRS.DataTypes;
using FoodieSite.CQRS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FoodieSite.API.Controllers
{
    /// <summary>
    /// Controller for managing user security operations such as registration, login, logout, and password reset.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        UserManager<AppUser> userManager;
        SignInManager<AppUser> signInManager;

        public SecurityController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        // Helper method to create an instance of AppUser using RegisterDTO object
        private AppUser GetUserObject(RegisterDTO objDTO)
        {
            return new AppUser()
            {
                FirstName = objDTO.FirstName,
                LastName = objDTO.LastName,
                Email = objDTO.Email,
                UserName = objDTO.Email,
                Password = objDTO.Password,
                Address = objDTO.Address,
                Contact1 = objDTO.Contact1,
                Contact2 = objDTO.Contact2
            };
        }

        /// <summary>
        /// API endpoint for user registration.
        /// </summary>
        /// <param name="objDTO">The registration data.</param>
        /// <returns>The registration response.</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO objDTO)
        {
            try
            {
                List<string> errorList = new List<string>();
                if (ModelState.IsValid)
                {
                    var user = GetUserObject(objDTO);
                    user.IsActive = true;
                    user.CreatedBy = user.Id;
                    user.CreatedDate = DateTime.UtcNow;

                    var userResult = await userManager.CreateAsync(user, objDTO.Password);
                    if (userResult.Succeeded)
                    {
                        var roleResult = await userManager.AddToRoleAsync(user, RoleTypes.User.ToString());
                        if (roleResult.Succeeded)
                        {
                            return StatusCode(200, new JsonResponseDTO()
                            {
                                IsSuccess = true,
                                StatusCode = 200,
                                Message = "User Registered Successfully",
                                Data = user
                            });
                        }
                        else
                        {
                            // Handle role assignment errors
                            foreach (var item in userResult.Errors)
                            {
                                errorList.Add(item.Description);
                            }
                            return StatusCode(400, new JsonResponseDTO()
                            {
                                IsSuccess = false,
                                StatusCode = 400,
                                Error = errorList
                            });
                        }
                    }
                    else
                    {
                        // Handle user creation errors
                        foreach (var item in userResult.Errors)
                        {
                            errorList.Add(item.Description);
                        }
                        return StatusCode(400, new JsonResponseDTO()
                        {
                            IsSuccess = false,
                            StatusCode = 400,
                            Error = errorList
                        });
                    }
                }

                // Return error response for invalid model state
                return StatusCode(400, new JsonResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Data = ModelState.Values
                });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, new JsonResponseDTO()
                {
                    IsSuccess = false,
                    Message = msg,
                    StatusCode = 500
                });
            }
        }

        /// <summary>
        /// API endpoint for user login.
        /// </summary>
        /// <param name="objDTO">The login credentials.</param>
        /// <returns>The login response.</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO objDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var signInResult = await signInManager.PasswordSignInAsync(objDTO.Email, objDTO.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                        var user = await userManager.FindByNameAsync(objDTO.Email);

                        return Ok(new JsonResponse()
                        {
                            IsSuccess = true,
                            Message = "User Login Successfully",
                            Data = user
                        });
                    }
                    else
                    {
                        // Handle login failure
                        return StatusCode(401, new JsonResponseDTO()
                        {
                            StatusCode = 401,
                            IsSuccess = false,
                            Message = "Username/Password is incorrect."
                        });
                    }
                }
                return StatusCode(400, new JsonResponseDTO()
                {
                    IsSuccess = false,
                    StatusCode = 400,
                    Data = ModelState.Values
                });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, new JsonResponseDTO()
                {
                    IsSuccess = false,
                    Message = msg,
                    StatusCode = 500
                });
            }
        }

        /// <summary>
        /// API endpoint for user logout.
        /// </summary>
        /// <returns>The logout response.</returns>
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
                return StatusCode(200, new JsonResponse()
                {
                    IsSuccess = true,
                    Message = "User Logout Successfully",
                    StatusCode = 200
                });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, new JsonResponseDTO()
                {
                    IsSuccess = false,
                    Message = msg,
                    StatusCode = 500
                });
            }
        }

        /// <summary>
        /// API endpoint for sending a password reset email.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <returns>The response with password reset token.</returns>
        [HttpGet]
        [Route("forgotPassword/{email}")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                // Find user in the database by user email
                var user = await userManager.FindByEmailAsync(email);

                if (user == null)
                    return StatusCode(401, new JsonResponseDTO()
                    {
                        IsSuccess = false,
                        Message = "Invalid Email",
                        StatusCode = 401
                    });

                // Generate Password Reset Token
                var token = await userManager.GeneratePasswordResetTokenAsync(user);

                return Ok(new JsonResponse()
                {
                    IsSuccess = true,
                    Message = "",
                    Data = new { PasswordResetToken = token }
                });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, new JsonResponseDTO()
                {
                    IsSuccess = false,
                    Message = msg,
                    StatusCode = 500
                });
            }
        }

        /// <summary>
        /// API endpoint for resetting user password.
        /// </summary>
        /// <param name="resetPasswordDTO">The password reset data.</param>
        /// <returns>The password reset response.</returns>
        [HttpPost]
        [Route("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            try
            {
                // Find user by email
                var user = await userManager.FindByEmailAsync(resetPasswordDTO.Email);
                if (user == null)
                {
                    return StatusCode(403, new JsonResponseDTO()
                    {
                        IsSuccess = false,
                        Message = "Invalid Email",
                        StatusCode = 403
                    });
                }

                // Verify password reset token
                var isValidToken = await userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, "ResetPassword",
                                                                           resetPasswordDTO.PasswordResetToken);
                if (!isValidToken)
                {
                    return StatusCode(403, new JsonResponseDTO()
                    {
                        IsSuccess = false,
                        Message = "Invalid Password Reset Token",
                        StatusCode = 403
                    });
                }

                // Password reset token is valid, reset the user's password
                var result = await userManager.ResetPasswordAsync(user, resetPasswordDTO.PasswordResetToken, resetPasswordDTO.NewPassword);
                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    return StatusCode(500, new JsonResponseDTO()
                    {
                        IsSuccess = false,
                        Message = "Failed to reset password",
                        StatusCode = 500,
                        Error = errors
                    });
                }

                // Password has been successfully reset
                return StatusCode(200, new JsonResponseDTO()
                {
                    IsSuccess = true,
                    Message = "Password has been reset successfully",
                    StatusCode = 200
                });
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, new JsonResponseDTO()
                {
                    IsSuccess = false,
                    Message = msg,
                    StatusCode = 500
                });
            }
        }
    }
}
