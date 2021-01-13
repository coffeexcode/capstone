using AttendanceAPI.Services;
using AttendanceAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/attendance")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        /// <summary>
        /// Gets all of the attendance records. Allows searching/filtering and sorting 
        /// with Sieve.
        /// 
        /// <see cref="https://github.com/Biarity/Sieve"/>
        /// 
        /// Can search/filter on:
        /// 1. UserId
        /// 2. EntityId
        /// 3. EntityType
        /// 4. ScanTime
        /// 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/attendance
        ///     
        /// </remarks>
        /// <returns>
        /// A list of all matching attendance records.
        /// </returns>
        /// <param name="sieveModel">The Sieve model for searching/filtering</param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(SieveModel sieveModel = null)
        {
            try
            {
                if (sieveModel == null)
                {
                    return Ok(await attendanceService.GetAllAsync());
                }
                else return Ok(await attendanceService.GetAllAsync(sieveModel));
            } 
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Gets a single attendace record by unique id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET /api/v1/attendance/{id}
        ///     
        /// </remarks>
        /// <returns>
        /// The matching attendace record, if found
        /// </returns>
        /// <param name="id">The id of the record to find. </param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetOne(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            try
            {
                var result = await this.attendanceService.GetByIdAsync(id);

                if (result == null)
                {
                    return NotFound();
                }
                else return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Creates an attendance record.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/v1/attendance
        ///     {
        ///         "userId": "",
        ///         "entityId": "",
        ///         "entityType": "",
        ///         "entityDescription": "",
        ///         "scanTime": ""
        ///     }
        /// </remarks>
        /// <param name="model">The details of the attendance record to create. </param>
        /// <returns>
        /// The newly created attendance record
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] AttendanceRecordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await attendanceService.CreateAsync(model);

                return CreatedAtAction(nameof(GetOne), new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
