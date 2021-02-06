import React from 'react';
import { render } from '@testing-library/react-native';

import PresentQR from '@screens/Attendee/PresentQR';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

describe('<PresentQR/>', () => {
  it('should render the View properly', () => {
    const tree = render(<PresentQR />).toJSON();
    expect(tree.type).toBe('View');
  })

  it('renders the placeholder QR code image', () => {
    const comp = render(<PresentQR />);
    const qr = comp.getByTestId('displayQR');
    expect(qr.type).toBe('Image')
  })
})