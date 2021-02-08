import { render, screen, fireEvent } from '@testing-library/react';
import { Statistics } from './index';

describe('<Statistics/>', () => {

    it('renders page header', () => {
        render(<Statistics />);
        const pageHeader = screen.getByText(/Event Statistics/i);
        expect(pageHeader).toBeInTheDocument();
    });

    it('renders sidebar', () => {
        render(<Statistics />);
        const sideBar = screen.getByText(/Manage Registration/i);
        expect(sideBar).toBeInTheDocument();
    });

    it('renders application status graph [ACCEPTANCE TEST (F-17)]', () => {
        render(<Statistics />);
        const appGraph = screen.getByText(/Application Status/i);
        expect(appGraph).toBeInTheDocument();
    });

    it('renders ticket type distribution graph [ACCEPTANCE TEST (F-17)]', () => {
        render(<Statistics />);
        const ticketGraph = screen.getByText(/Ticket Type Distribution/i);
        expect(ticketGraph).toBeInTheDocument();

    });

    it('renders age distribution graph [ACCEPTANCE TEST (F-16)]', () => {
        render(<Statistics />);
        const ageGraph = screen.getByText(/Age Distribution/i);
        expect(ageGraph).toBeInTheDocument();

    });

    it('renders geographic distribution graph [ACCEPTANCE TEST (F-16)]', () => {
        render(<Statistics />);
        const geoGraph = screen.getByText(/Geographic Distribution/i);
        expect(geoGraph).toBeInTheDocument();

    });

    it('renders number cards for application status and ticket type distribution graphs [ACCEPTANCE TEST (F-17)]', () => {
        render(<Statistics />);
        const pendingCard = screen.getByText(/Pending/i);
        const acceptedCard = screen.getByText(/Accepted/i);
        const rejectedCard = screen.getByText(/Rejected/i);
        const standardCard = screen.getByText(/Standard/i);
        const fullaccessCard = screen.getByText(/Full-Access/i);
        const vipCard = screen.getByText(/VIP/i);
        
        expect(pendingCard).toBeInTheDocument();
        expect(acceptedCard).toBeInTheDocument();
        expect(rejectedCard).toBeInTheDocument();
        expect(standardCard).toBeInTheDocument();
        expect(fullaccessCard).toBeInTheDocument();
        expect(vipCard).toBeInTheDocument();
    });

})