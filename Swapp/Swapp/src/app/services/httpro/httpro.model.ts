export class HttproModel {
    value: any;
    message = "";
    hasError = false;
    isLoading = false;
    status = "ready";

    private defaultValue = null;

    constructor(defaultValue = null) {
        this.defaultValue = defaultValue;
        this.Reset(); 
    }
    public isGood() {
        return this.getStatus() === 'value' && this.defaultValue !== this.value;
    }
    public getStatus() {
        if (this.hasError)
            return 'error';
        if (this.message.length > 0 || this.isLoading)
            return 'message';

        return 'value';
    }
    public Reset() {
        this.message = "";
        this.hasError = false;
        this.isLoading = false;
        this.status = "ready";
        this.ResetValue();
    }
    public ResetValue() {
        this.value = this.defaultValue;
    }
    public toDebugJSON() {
        return {
            message: this.message,
            hasError: this.hasError,
            defaultValue: this.defaultValue,
            value: this.value,
        };
    }
}