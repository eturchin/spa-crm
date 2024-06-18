export const constants= { 
    ACCESS_TOKNE: 'ACCESS_TOKEN',
}

const apiUrl = 'https://localhost:7107'

export const apiEndpoint = {
    AuthEndpoint: {
        login: `${apiUrl}/User/Login`,
        register: `${apiUrl}/User/Register`
    },
    UserEndpoint: {
        getMe: `${apiUrl}/User/GetMe`
    },
    ServiceEndpoint: {
        getServices: `${apiUrl}/Service/GetServices`
    },
    SpecialistEndpoint: {
        getSpecialists: `${apiUrl}/Specialist/GetSpecialists`
    },
    BookingEndpoint: {
        createBooking: `${apiUrl}/Booking/CreateBooking`,
        getMyAppointments: `${apiUrl}/Booking/GetMyAppointments`
    }
}