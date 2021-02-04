import { render, screen } from '@testing-library/react';
import { Banner } from './index';

test('renders learn react link', () => {
  render(<Banner />);
  const linkElement = screen.getByText(/About/i);
  expect(linkElement).toBeInTheDocument();
});
