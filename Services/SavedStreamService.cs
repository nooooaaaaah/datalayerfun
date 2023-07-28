using WNBOT.Classes.DO.SavedStream;
using WNBOT.Classes.DTO.SavedStream;

namespace WNBOT.Services.SavedStream
{
    public class SavedStreamService
    {
        private readonly DatabaseContext _dbContext;

        public SavedStreamService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SavedStreamDTO>? GetAllSavedStreams()
        {
            if (_dbContext.SavedStreams == null)
            {
                return null;
            }
            List<SavedStreamData> savedStreams = _dbContext.SavedStreams.ToList();
            return savedStreams.Select(MapSavedStreamDOToDTO).ToList();
        }

        public SavedStreamDTO? GetSavedStreamById(int savedStreamId)
        {
            if (_dbContext.SavedStreams == null)
            {
                return null;
            }
            SavedStreamData? savedStream = _dbContext.SavedStreams.FirstOrDefault(s => s.savedStreamId == savedStreamId);
            return savedStream != null ? MapSavedStreamDOToDTO(savedStream) : null;
        }
        public bool AddSavedStream(SavedStreamDTO savedStreamDTO)
        {
            if (_dbContext.SavedStreams == null)
            {
                return false;
            }
            SavedStreamData savedStream = MapSavedStreamDTOToDO(savedStreamDTO);
            _dbContext.SavedStreams.Add(savedStream);
            _dbContext.SaveChanges();
            return true;
        }
        public bool UpdateSavedStreams(SavedStreamDTO savedStreamDTO)
        {
            if (_dbContext.SavedStreams == null)
            {
                return false;
            }
            SavedStreamData? existingSavedStream = _dbContext.SavedStreams.FirstOrDefault(s => s.savedStreamId == savedStreamDTO.savedStreamId);
            if (existingSavedStream != null)
            {
                existingSavedStream.startTime = savedStreamDTO.startTime;
                existingSavedStream.viewers = savedStreamDTO.viewers;
                existingSavedStream.streamKey = savedStreamDTO.streamKey;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteSavedStream(int savedStreamId)
        {
            if (_dbContext.SavedStreams == null)
            {
                return false;
            }
            SavedStreamData? savedStream = _dbContext.SavedStreams.FirstOrDefault(s => s.savedStreamId == savedStreamId);
            if (savedStream != null)
            {
                _dbContext.SavedStreams.Remove(savedStream);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public SavedStreamDTO MapSavedStreamDOToDTO(SavedStreamData savedStream)
        {
            return new SavedStreamDTO
            {
                savedStreamId = savedStream.savedStreamId,
                startTime = savedStream.startTime,
                streamKey = savedStream.streamKey,
                viewers = savedStream.viewers,
                category = savedStream.category,
                sellerId = savedStream.sellerId,
            };
        }
        public static SavedStreamData MapSavedStreamDTOToDO(SavedStreamDTO savedStreamDTO)
        {
            return new SavedStreamData
            {
                savedStreamId = savedStreamDTO.savedStreamId,
                startTime = savedStreamDTO.startTime,
                streamKey = savedStreamDTO.streamKey,
                viewers = savedStreamDTO.viewers,
                category = savedStreamDTO.category,
                sellerId = savedStreamDTO.sellerId,
            };
        }
    }
}