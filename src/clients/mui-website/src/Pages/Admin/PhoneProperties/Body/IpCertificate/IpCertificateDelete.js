import { Alert, Button, TextField, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams, Link, useNavigate } from "react-router-dom";
import * as IpCertificateService from "../../../../../Services/IpCertificateService";
import { Box } from "@mui/system";

function IpCertificateDelete() {
  const { id } = useParams();
  const navigate = useNavigate();
  const mainUrl = "/admin/body/ip-certificate";
  const [ipCertificate, setIpCertificate] = useState({ id: "", name: "" });
  const [error, setError] = useState("");

  // Load ip certificate
  useEffect(() => {
    IpCertificateService.getIpCertificate(id)
      .then((res) => {
        if (res.status === 200 && res.data.success) {
          setIpCertificate(res.data.data);
        }
      })
      .catch((err) => setError("Cannot find Ip Certificate"));
  }, []);

  function handleSubmit(e) {
    IpCertificateService.deleteIpCertificate(id);
    navigate(mainUrl);
    navigate(0);
    e.preventDefault();
  }

  return (
    <>
      <Typography variant="h6">Delete Ip Certificate</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <form onSubmit={handleSubmit}>
        <Box sx={{ mt: 2 }}>
          <input readOnly hidden id="id" name="id" value={id} />

          <Typography variant="body1">
            Are you sure you want to DELETE the following Ip Certificate?
          </Typography>

          <Typography variant="h4">{ipCertificate.name}</Typography>
        </Box>

        <Box sx={{ mt: 2 }}>
          <Button color="error" variant="contained" type="submit">
            YES, I WANT TO DELETE THE IP CERTIFICATE
          </Button>
          <Button
            component={Link}
            to={mainUrl}
            sx={{ ml: 1, background: "grey" }}
            variant="contained"
          >
            Back
          </Button>
        </Box>
      </form>
    </>
  )
}

export default IpCertificateDelete