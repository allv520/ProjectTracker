using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll(int? sortStrategy)
        {
            try
            {
                if (sortStrategy == null)
                {
                    return Ok(Summaries);
                }
                else if (sortStrategy == 1)
                {
                    return Ok(Summaries.OrderBy(x => x).ToList());
                }
                else if (sortStrategy == -1)
                {
                    return Ok(Summaries.OrderByDescending(x => x).ToList());
                }
                else
                {
                    return BadRequest("Некорректное значение параметра sortStrategy");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Некорректное значение параметра sortStrategy");
                return StatusCode(500, "Некорректное значение параметра sortStrategy");
            }
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Некорректное значение параметра sortStrategy");
                }

                Summaries.Add(name);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Некорректное значение параметра sortStrategy");
                return StatusCode(500, "Некорректное значение параметра sortStrategy");
            }
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            try
            {
                if (index < 0 || index >= Summaries.Count)
                {
                    return BadRequest("Некорректное значение параметра sortStrategy");
                }

                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Некорректное значение параметра sortStrategy");
                }

                Summaries[index] = name;
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Некорректное значение параметра sortStrategy");
                return StatusCode(500, "Некорректное значение параметра sortStrategy");
            }
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            try
            {
                if (index < 0 || index >= Summaries.Count)
                {
                    return BadRequest("Некорректное значение параметра sortStrategy");
                }

                Summaries.RemoveAt(index);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Некорректное значение параметра sortStrategy");
                return StatusCode(500, "Некорректное значение параметра sortStrategy");
            }
        }
        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {
            try
            {
                if (index < 0 || index >= Summaries.Count)
                {
                    return BadRequest("Некорректное значение параметра sortStrategy");
                }

                return Ok(Summaries[index]);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Некорректное значение параметра sortStrategy");
                return StatusCode(500, "Некорректное значение параметра sortStrategy");
            }
        }

        [HttpGet("count-by-name")]
        public IActionResult GetCountByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Некорректное значение параметра sortStrategy");
                }

                var count = Summaries.Count(x => x.Equals(name, StringComparison.OrdinalIgnoreCase));
                return Ok(count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Некорректное значение параметра sortStrategy");
                return StatusCode(500, "Некорректное значение параметра sortStrategy");
            }
        }
    }
}


