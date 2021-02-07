import { getCount, getCountRange, getTopLocations, getSumOfLocationsCount } from '@utils/stats'

const options = {
    "Content-Type": "application/json",
    "Accept": "application/json",
};

describe('stats', () => {

    const invalidDataset = ['hello'];
    const emptyDataset = [{}];
    const emptyDataset2 = [];
    const oneApplicantDataset = [{ "id": "efcbc2e5-a4c9-4789-ad51-b69a6e76e7c5", "name": "Edward Kuvalis", "email": "Maci41@yahoo.com", "address": { "street": "38066 Aletha Expressway", "city": "Abbotthaven", "country": "United States of America", "state": "Massachusetts", "zipCode": "34871" }, "age": 27, "phone": "758.312.0327 x79682", "status": "Pending", "type": "Standard" }];
    const regularApplicantDataset = require("../../public/data/data", options)["users"];


    describe('getCount', () => {
        it('should return 0 if an empty dataset is given', () => {
            expect(getCount(emptyDataset, 'status', 'Accepted')).toEqual(0);
        })

        it('should return 0 if a no one in a dataset meets the criteria', () => {
            expect(getCount(oneApplicantDataset, 'status', 'Accepted')).toEqual(0);
            expect(getCount(oneApplicantDataset, 'type', 'VIP')).toEqual(0);
            expect(getCount(oneApplicantDataset, 'age', 25)).toEqual(0);
        })

        it('should return 0 if criteria is entered wrong', () => {
            expect(getCount(oneApplicantDataset, 'status', 'accepted')).toEqual(0);
            expect(getCount(oneApplicantDataset, 'type', 'vip')).toEqual(0);
        })

        it('should throw an error if name of property is entered wrong', () => {
            expect(getCount(oneApplicantDataset, 'Status', 'Pending')).toThrowError;
            expect(getCount(oneApplicantDataset, 'Type', 'Standard')).toThrowError;
            expect(getCount(oneApplicantDataset, 'Age', 27)).toThrowError;
        })

        it('should throw an error if data is in an incorrect format', () => {
            expect(getCount(invalidDataset, 'status', 'Pending')).toThrowError;
        })

        it('should return 1 if a dataset of one applicant meets the criteria', () => {
            expect(getCount(oneApplicantDataset, 'status', 'Pending')).toEqual(1);
            expect(getCount(oneApplicantDataset, 'type', 'Standard')).toEqual(1);
            expect(getCount(oneApplicantDataset, 'age', 27)).toEqual(1);
        })

        it('should return a value based on a valid property and criteria in a given dataset of 2000 applicants', () => {
            expect(getCount(regularApplicantDataset, 'status', 'Pending')).toBeGreaterThanOrEqual(1);
            expect(getCount(regularApplicantDataset, 'status', 'Accepted')).toBeGreaterThanOrEqual(1);
            expect(getCount(regularApplicantDataset, 'status', 'Rejected')).toBeGreaterThanOrEqual(1);
            expect(getCount(regularApplicantDataset, 'type', 'Standard')).toBeGreaterThanOrEqual(1);
            expect(getCount(regularApplicantDataset, 'type', 'Full-Access')).toBeGreaterThanOrEqual(1);
            expect(getCount(regularApplicantDataset, 'type', 'VIP')).toBeGreaterThanOrEqual(1);
        })
    });

    describe('getCountRange', () => {

        it('should return 0 if an empty dataset is given', () => {
            expect(getCountRange(emptyDataset, 'age', 18, 25)).toEqual(0);
        })

        it('should return 0 if a no one in a dataset meets the criteria', () => {
            expect(getCountRange(oneApplicantDataset, 'age', 18, 25)).toEqual(0);
        })

        it('should throw an error if name of property is entered wrong', () => {
            expect(getCountRange(oneApplicantDataset, 'Age', 26, 35)).toThrowError;
            expect(getCountRange(oneApplicantDataset, 'type', 26, 35)).toEqual(0);
        })

        it('should throw an error if data is in an incorrect format', () => {
            expect(getCountRange(invalidDataset, 'age', 18, 25)).toThrowError;
        })

        it('should throw an error if criteria is an incorrect datatype', () => {
            expect(getCountRange(oneApplicantDataset, 'age', 'Eighteen', 25)).toThrowError;
            expect(getCountRange(oneApplicantDataset, 'age', '18', 25)).toThrowError;
            expect(getCountRange(oneApplicantDataset, 'age', 18, 'Twenty-five')).toThrowError;
            expect(getCountRange(oneApplicantDataset, 'age', 18, '25')).toThrowError;
        })

        it('should return 1 if a dataset of one applicant meets the criteria', () => {
            expect(getCountRange(oneApplicantDataset, "age", 26, 35)).toEqual(1);
        })

        it('should return a value based on a valid property and criteria in a given dataset of 2000 applicants', () => {
            expect(getCountRange(regularApplicantDataset, 'age', 18, 25)).toBeGreaterThanOrEqual(1);
            expect(getCountRange(regularApplicantDataset, 'age', 26, 35)).toBeGreaterThanOrEqual(1);
            expect(getCountRange(regularApplicantDataset, 'age', 36, 45)).toBeGreaterThanOrEqual(1);
            expect(getCountRange(regularApplicantDataset, 'age', 46, 55)).toBeGreaterThanOrEqual(1);
            expect(getCountRange(regularApplicantDataset, 'age', 56, 65)).toBeGreaterThanOrEqual(1);
            expect(getCountRange(regularApplicantDataset, 'age', 65, 100)).toBeGreaterThanOrEqual(1);
        })

    });

    describe('getTopLocations', () => {

        it('should return an empty array if an empty dataset is given', () => {
            expect(getTopLocations(emptyDataset2)).toHaveLength(0);
        })

        it('should throw an error if data is in an incorrect format', () => {
            expect(getTopLocations(invalidDataset)).toThrowError;
            expect(getTopLocations(emptyDataset)).toThrowError;
        })

        it('should return 1 if given a dataset of one applicant', () => {
            expect(getTopLocations(oneApplicantDataset)).toHaveLength(1);
        })

        it('should return a value in a given dataset of 2000 applicants', () => {
            expect(getTopLocations(regularApplicantDataset).length).toBeGreaterThanOrEqual(1);
        })

    });

    describe('getSumOfLocationsCount', () => {

        it('should return 0 if an empty dataset is given', () => {
            expect(getSumOfLocationsCount(getTopLocations(emptyDataset2), 0)).toEqual(0);
            expect(getSumOfLocationsCount([], 0)).toEqual(0);
        })

        it('should throw an error if data is in an incorrect format', () => {
            expect(getSumOfLocationsCount(invalidDataset)).toThrowError;
            expect(getSumOfLocationsCount(emptyDataset)).toThrowError;
        })

        it('should return 1 if given a dataset of one applicant', () => {
            expect(getSumOfLocationsCount(getTopLocations(oneApplicantDataset), 0)).toEqual(1);
        })

        it('should throw an error if given a valid dataset but the start index is past the array range', () => {
            expect(getSumOfLocationsCount(getTopLocations(oneApplicantDataset), 1)).toThrowError;
            expect(getSumOfLocationsCount(getTopLocations(emptyDataset2), 1)).toThrowError;
            expect(getSumOfLocationsCount(getTopLocations(regularApplicantDataset), 2000)).toThrowError;
        })

        it('should return a value in a given dataset of 2000 applicants', () => {
            expect(getSumOfLocationsCount(getTopLocations(regularApplicantDataset),0)).toBeGreaterThanOrEqual(1);
        })

    });


});
