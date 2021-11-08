using AutoMapper;
using MemberApi.DAL.Entities;
using MemberApi.DAL.Repositories;
using MemberApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        public MemberController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public IActionResult GetAllMembers()
        {
            try
            {
                var members = _memberRepository.GetAll();
                var memberDtosResult = _mapper.Map<IEnumerable<Member>, IEnumerable<MemberDtoRead>>(members);
                return Ok(memberDtosResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/<MemberController>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Value must be passed in the request body");
                }
                var member = _memberRepository.GetMemberById(id);
                if (member == null)
                {
                    return NotFound();
                }
                else
                {
                    var memberDtosResult = _mapper.Map<Member, MemberDtoRead>(member);
                    return Ok(memberDtosResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<MemberController>
        [HttpPost]
        public IActionResult CreateMember([FromBody] MemberDtoWrite member)
        {
            try
            {
                if (member == null)
                {
                    return BadRequest("member is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var memberEntity = _mapper.Map<Member>(member);
                _memberRepository.Create(memberEntity);

                var createdMember = _mapper.Map<MemberDtoRead>(memberEntity);
                return Ok(member);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, [FromBody] MemberDtoWrite member)
        {
            try
            {
                if (member == null)
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var memberEntity = _memberRepository.GetMemberById(id);
                if (memberEntity == null)
                {
                    return NotFound();
                }
                _mapper.Map(member, memberEntity);
                _memberRepository.Update(memberEntity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var member = _memberRepository.GetMemberById(id);
                if (member == null)
                {
                    return NotFound();
                }
                else
                {
                    _memberRepository.Delete(member);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

