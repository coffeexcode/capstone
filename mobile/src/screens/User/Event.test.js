import React from 'react';
import { fireEvent, render } from '@testing-library/react-native';

import Event from '@screens/User/Event';

jest.mock('@expo/vector-icons');
jest.useFakeTimers();
global.fetch = jest.fn(() => Promise.resolve({}));

describe('<Event/>', () => {
  const constructRoute = (past, type, status) => {

    const today = new Date();
    let eventDate;
    
    if (past === undefined) {
      eventDate = today;
    } 
    else if (past === true) {
      const yesterday = new Date(today);
      yesterday.setDate(today.getDate() - 1);
      eventDate = yesterday;
    } else {
      const tomorrow = new Date(today);
      tomorrow.setDate(today.getDate() + 1);
      eventDate = tomorrow;
    }

    const defaultStatus = 'UNREGISTERED';
    const defaultType = 'default';

    return {
      params: {
        item: {
          name: 'testEvent',
          description: 'testDescription',
          roomId: 'testRoomId',
          type: type || defaultType,
          start: eventDate,
          status: status || defaultStatus,
          startTime: '9',
          endTime: '11'
        }
      }
    }
  }

  it('should render the View properly', () => {
    const route = constructRoute();
    const tree = render(<Event route={route} />).toJSON();
    expect(tree.type).toBe('View');
  })

  it('should display the event name', () => {
    const route = constructRoute();
    const comp = render(<Event route={route} />);
    const text = comp.getByTestId('eventName');
    expect(text.children[0]).toBeTruthy();
  })

  it('should display the event description', () => {
    const route = constructRoute();
    const comp = render(<Event route={route} />);
    const text = comp.getByTestId('eventDescription');
    expect(text.children[0]).toBeTruthy();
  })

  it('should display the proper registration status for the event', () => {
    const route = constructRoute(false, undefined, 'REGISTERED');
    const comp = render(<Event route={route}/>);
    const text = comp.getByTestId('registrationStatus'); 
    expect(text.children[0]).toBe('REGISTERED');
  })

  it('should not toggle the registration if the event is over [ACCEPTANCE TEST (F-12)]', () => {
    const route = constructRoute(true);
    const comp = render(<Event route={route} />);
    const button = comp.getByTestId('toggleRegistration');

    const text = comp.getByTestId('registrationStatus');

    fireEvent(button, 'press');

    expect(text.props.children).toBe('THIS EVENT HAS ENDED');
  })

  it('should register the user if the user toggles the current unregistered event [ACCEPTANCE TEST (F-11)]', () => {
    const route = constructRoute(false, undefined, 'UNREGISTERED');
    const comp = render(<Event route={route}/>);
    const button = comp.getByTestId('toggleRegistration');

    const text = comp.getByTestId('registrationStatus');

    expect(text.props.children).toBe('UNREGISTERED');

    fireEvent(button, 'press');

    expect(text.props.children).toBe('REGISTERED');
  })

  it('should unregister the user if the user toggles the current registered event [ACCEPTANCE TEST (F-13)]', () => {
    const route = constructRoute(false, undefined, 'REGISTERED');
    const comp = render(<Event route={route}/>);
    const button = comp.getByTestId('toggleRegistration');

    const text = comp.getByTestId('registrationStatus');

    expect(text.props.children).toBe('REGISTERED');

    fireEvent(button, 'press');

    expect(text.props.children).toBe('NOT REGISTERED');
  })
})
