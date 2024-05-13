using System;
using Vagtsystem.Shared.Models;

namespace Vagtsystem.Server.Repositories
{
	public interface IFestivalRepo
	{
        Task<bool> CreateFrivillig(Frivillig frivillig);
        Task<List<Frivillig>> GetFrivilligList();
        Task<List<Vagt>> GetFrivilligVagtList(int vagt_id);
        Task<List<Frivillig>> GetFrivilligView();
        Task<Frivillig> GetFrivilligViewId(int frivillig_id);
        Task<Frivillig> GetFrivillig(int id);
        Task<Frivillig> UpdateFrivillig(Frivillig frivillig);
        Task<bool> DeleteFrivillig(int key);
        Task<bool> CreateVagt(Vagt fvagt);
        Task<bool> CreateHoldVagt(Vagt vagt);
        Task<List<Vagt>> GetVagtList();
        Task<Vagt> GetVagt(int id);
        Task<List<Vagt>> GetBrugerVagter(int frivillig_id);
        Task<List<Vagt>> GetAlleBrugerVagter(int id);
        Task<Vagt> GetBrugerVagt(int frivillig_vagt_id);
        Task<List<Vagt>> GetKoordVagt(int hold_id, int sort);
        Task<List<Vagt>> GetHoldVagt(int id);
        Task<List<Hold>> GetHold();
        Task<List<Stilling>> GetStilling();
        Task<Vagt> UpdateVagt(Vagt vagt);
        Task<bool> DeleteVagt(int key);
        Task<bool> DeleteHoldVagt(int vagt_id);
    }
}

