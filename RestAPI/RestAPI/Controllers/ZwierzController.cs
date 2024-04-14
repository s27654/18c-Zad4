using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/zwierzeta")]
    public class ZwierzController : ControllerBase
    {
        [HttpGet("list")]
        public IActionResult GetZwierza()
        {
            var zwierzeta = DB.Zwierzeta;
            return Ok(zwierzeta);
        }

        [HttpGet("{id:int}wizyta")]
        public IActionResult GetById(int id)
        {
            var zwierz = DB.Zwierzeta.FirstOrDefault(z => z.Id == id);
            if (zwierz == null)
                return NotFound($"Zwierz z id {id} nie znaleziony");
            return Ok(zwierz);
        }

        [HttpPost("{id:int}wizyta")]
        public IActionResult AddZwierz([FromBody] Zwierz zwierze)
        {
            if (DB.Zwierzeta.Any(z => z.Id == zwierze.Id))
                return Conflict($"Zwierze o id {zwierze.Id} już w bazie");
            DB.Zwierzeta.Add(zwierze);
            return Created($"/api/zwierzeta/{zwierze.Id}", zwierze);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateZwierz(int id, [FromBody] Zwierz zwierz)
        {
            var obecne = DB.Zwierzeta.FirstOrDefault(z => z.Id == id);
            if(obecne == null)
                return NotFound($"Zwierz z id {id} nie znaleziony");
            if (zwierz.Name != null)
                obecne.Name = zwierz.Name;
            if (zwierz.Kat != null)
                obecne.Name = zwierz.Name;
            if (zwierz.Waga != 0)
                obecne.Waga = zwierz.Waga;
            if (zwierz.Kolor != null)
            {
                obecne.Kolor = zwierz.Kolor;
            }

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteZwierze([FromRoute] int id)
        {
            var zwierz = DB.Zwierzeta.FirstOrDefault(st => st.Id == id);
            if (zwierz is null) 
                return NotFound($"Zwierz z id {id} nie znaleziony");
            DB.Zwierzeta.Remove(zwierz);
            return NoContent(); //Ok();
        }

        [HttpPost("{id:int}/wizyty")]
        public IActionResult AddWizyta(int id, [FromBody] Wizyta wizyta)
        {
            var zwierze = DB.Zwierzeta.FirstOrDefault(z => z.Id == id);
            if (zwierze == null)
                return NotFound($"Zwierz z id {id} nie znaleziony");
            wizyta.Zwierze = zwierze;
            DB.Wizyty.Add(wizyta);
            return Created($"/api/zwierzeta/{id}/wizyty/{wizyta.Data}", wizyta);
        }
    }
}