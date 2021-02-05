import React from 'react';
import { render, fireEvent } from '@testing-library/react-native';

import SelectView from '@screens/Onboarding/SelectView';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();

describe('<SelectView/>', () => {
  const navigation = {
    navigate: jest.fn()
  };

  it('should render the View properly', () => {
    const tree = render(<SelectView/>).toJSON();
    expect(tree.type).toBe('View');
  })

  it('should navigate to the Organizers home when Organizer is selected', () => {
    const comp = render(<SelectView navigation={navigation}/>);
    const button = comp.getByTestId('organizerBtn');

    fireEvent(button, 'press');
    expect(navigation.navigate).toHaveBeenCalledWith('OrganizerHome');
  })

  it('should navigate to the Organizers home when Sponsor is selected', () => {
    const comp = render(<SelectView navigation={navigation}/>);
    const button = comp.getByTestId('sponsorBtn');

    fireEvent(button, 'press');
    expect(navigation.navigate).toHaveBeenCalledWith('OrganizerHome');
  })

  it('should navigate to the Attendee home when Attendee is selected', () => {
    const comp = render(<SelectView navigation={navigation}/>);
    const button = comp.getByTestId('attendeeBtn');

    fireEvent(button, 'press');
    expect(navigation.navigate).toHaveBeenCalledWith('AttendeeHome');
  })
})
