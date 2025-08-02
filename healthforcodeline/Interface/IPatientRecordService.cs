using hospitalsystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalSystem.Interface
{
    public interface IPatientRecordService
    {//

       // The interface will serve as the foundation for implementing patient record
//management functionality, enabling CRUD operations and patient-specific record
//retrieval in the hospital system


        //create new patient medical records
        void AddRecord(PatientRecord record);
        //retrieve all existing records
        List<PatientRecord> GetAllRecords();
     
        //fetch a specific record by its ID
        PatientRecord? GetRecordById(int id);
        // to find all records for a particular patient
        List<PatientRecord> GetRecordsByPatientId(int patientId);
    }
}
