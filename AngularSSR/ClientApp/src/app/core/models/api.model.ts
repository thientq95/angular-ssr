export class ApiResponse<T> {
    data: T;
    message: string;
    statusCode: number;
}