using ClassLibrary;
using System;
using System.Text.RegularExpressions;

namespace Importer
{
    public class ValidationError
    {
        /// <summary>
        /// CSVファイルの各項目のバリデーション
        /// </summary>
        /// <param name="item"></param>
        public void ValidateItems(CsvItem item)
        {
            //オーダー番号のバリデーション
            ValidateOrderNumber(item.OrderNumber);
            //検査日付のバリデーション
            ValidateScheduledOn(item.ScheduledOn);
            //処理区分のバリデーション
            ValidateProcessingDivision(item.ProcessingDivision);
            //検査種別コードのバリデーション
            ValidateStudyTypeCode(item.StudyTypeCode);
            //検査種別名称のバリデーション
            ValidateStudyTypeName(item.StudyTypeName);
            //患者IDのバリデーション
            ValidatePatientId(item.PatientId);
            //患者漢字氏名のバリデーション
            ValidatePatientKanjiName(item.PatientKanjiName);
            //患者カナ氏名のバリデーション
            ValidatePatientKanaName(item.PatientKanaName);
            //生年月日のバリデーション
            ValidatePatientBirthDate(item.PatientBirthDate);
            //性別のバリデーション
            ValidatePatientGender(item.PatientGender);

            foreach (var shotItem in item.ShotItemSet)
            {
                //撮影項目コードのバリデーション
                ValidateShotItemCode(shotItem.ShotItemCode);
                //撮影項目名称のバリデーション
                ValidateShotItemName(shotItem.ShotItemName);
            }

        }

        /// <summary>
        /// オーダー番号は8文字の半角数字列
        /// </summary>
        /// <param name="orderNumber"></param>
        private void ValidateOrderNumber(string orderNumber)
        {
            Regex regex = new Regex(@"^[0-9]{8}$");

            if (!regex.IsMatch(orderNumber))
            {
                throw new OrderNumberException(orderNumber);
            }
        }

        /// <summary>
        /// 検査日付は有効な日付を表すyyyymmdd形式の半角数字列
        /// </summary>
        /// <param name="scheduledOn"></param>
        private void ValidateScheduledOn(string scheduledOn)
        {
            DateTime dateTime;

            if (!DateTime.TryParse(scheduledOn, out dateTime))
            {
                throw new ScheduledOnException(scheduledOn);
            }
        }

        /// <summary>
        /// 処理区分は1文字の半角数字
        /// </summary>
        /// <param name="processingDivision"></param>
        private void ValidateProcessingDivision(string processingDivision)
        {
            Regex regex = new Regex(@"^[123]{1}$");

            if (!regex.IsMatch(processingDivision))
            {
                throw new ProcessingDivisionException(processingDivision);
            }
        }

        /// <summary>
        /// 検査種別コードは1文字以上、8文字以下の半角英数字列
        /// </summary>
        /// <param name="studyTypeCode"></param>
        private void ValidateStudyTypeCode(string studyTypeCode)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]{1,8}$");

            if (!regex.IsMatch(studyTypeCode))
            {
                throw new StudyTypeCodeException(studyTypeCode);
            }
        }

        /// <summary>
        /// 検査種別名称1文字以上、32文字以下の任意の文字列
        /// </summary>
        /// <param name="studyTypeName"></param>
        private void ValidateStudyTypeName(string studyTypeName)
        {
            Regex regex = new Regex(@"^.{1,32}$");

            if (!regex.IsMatch(studyTypeName))
            {
                throw new StudyTypeNameException(studyTypeName);
            }
        }

        /// <summary>
        /// 患者IDは10文字の半角英数字列
        /// </summary>
        /// <param name="patientId"></param>
        private void ValidatePatientId(string patientId)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]{10}$");

            if (!regex.IsMatch(patientId))
            {
                throw new PatientIdException(patientId);
            }
        }

        /// <summary>
        /// 患者漢字氏名は1文字以上64文字以下の任意の文字列
        /// </summary>
        /// <param name="patientKanjiName"></param>
        private void ValidatePatientKanjiName(string patientKanjiName)
        {
            Regex regex = new Regex(@"^.{1,64}$");

            if (!regex.IsMatch(patientKanjiName))
            {
                throw new PatientKanjiNameException(patientKanjiName);
            }
        }

        /// <summary>
        /// 患者カナ氏名は1文字以上64文字以下の任意の文字列
        /// </summary>
        /// <param name="patientKanaName"></param>
        private void ValidatePatientKanaName(string patientKanaName)
        {
            Regex regex = new Regex(@"^.{1,64}$");

            if (!regex.IsMatch(patientKanaName))
            {
                throw new PatientKanaNameException(patientKanaName);
            }
        }

        /// <summary>
        /// 生年月日は有効な日付を表すyyyymmdd形式の半角数字列
        /// </summary>
        /// <param name="patientBirthDate"></param>
        private void ValidatePatientBirthDate(string patientBirthDate)
        {
            DateTime dateTime;

            if (!DateTime.TryParse(patientBirthDate, out dateTime))
            {
                throw new PatientBirthDateException(patientBirthDate);
            }
        }

        /// <summary>
        /// 性別はDICOM形式の性別(F, M, O)のいずれか
        /// </summary>
        /// <param name="patientGender"></param>
        private void ValidatePatientGender(string patientGender)
        {
            Regex regex = new Regex(@"^[FMO]{1}$");

            if (!regex.IsMatch(patientGender))
            {
                throw new PatientGenderException(patientGender);
            }
        }

        /// <summary>
        /// 撮影項目コードは1文字以上、8文字以下の半角英数字列
        /// </summary>
        /// <param name="shotItemCode"></param>
        private void ValidateShotItemCode(string shotItemCode)
        {
            Regex regex = new Regex(@"^[-0-9a-zA-Z]{1,8}$");

            if (!regex.IsMatch(shotItemCode))
            {
                throw new ShotItemCodeException(shotItemCode);
            }
        }

        /// <summary>
        /// 撮影項目名称は1文字以上、32文字以下の任意の文字列
        /// </summary>
        /// <param name="shotItemName"></param>
        private void ValidateShotItemName(string shotItemName)
        {
            Regex regex = new Regex(@"^.{1,32}$");

            if (!regex.IsMatch(shotItemName))
            {
                throw new ShotItemNameException(shotItemName);
            }
        }
    }
}
